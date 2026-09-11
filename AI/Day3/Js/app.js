/* ============================================
   CONFIG
   ============================================ */
const API_KEY = "fw_TKni9HixLQxknD18Zdka78";

let mode = "chat";
let chatHistory    = [];   // messages sent to the AI (full conversation)
let sessionHistory = [];   // UI history list (sidebar)


/* ============================================
   MODE
   ============================================ */
function setMode(m) {
  mode = m;

  document.getElementById("btnChat").classList.toggle("active",  m === "chat");
  document.getElementById("btnImage").classList.toggle("active", m === "image");

  const pill = document.getElementById("modePill");
  pill.className   = "mode-pill " + m;
  pill.textContent = m === "chat" ? "Chat" : "Image";

  document.getElementById("inputHint").textContent = m === "chat"
    ? "Chat mode — ask me anything"
    : "Image mode — describe what you want to create";

  document.getElementById("prompt").placeholder = m === "chat"
    ? "Type a message..."
    : "Describe an image...";
}


/* ============================================
   SEND HANDLER
   ============================================ */
async function handleSend() {
  const input = document.getElementById("prompt");
  const msg   = input.value.trim();
  if (!msg) return;

  hideWelcome();
  addMessage(msg, "user");
  input.value = "";
  document.getElementById("sendBtn").disabled = true;

  chatHistory.push({ role: "user", content: msg });

  const typingEl = addTyping();

  if (mode === "chat") {
    const res = await sendChat();
    typingEl.remove();
    addMessage(res, "bot");
    chatHistory.push({ role: "assistant", content: res });
    addToHistory("chat", msg, null);

  } else {
    const imgUrl = await sendImage(msg);
    typingEl.remove();

    if (imgUrl) {
      addImageMsg(imgUrl);
      chatHistory.push({ role: "assistant", content: "[Image generated]" });
      addToHistory("image", msg, imgUrl);
    } else {
      addMessage("Could not generate image. Check your API key or try again.", "bot");
    }
  }

  document.getElementById("sendBtn").disabled = false;
}

/* Enter key to send */
document.getElementById("prompt").addEventListener("keydown", function(e) {
  if (e.key === "Enter" && !e.shiftKey) {
    e.preventDefault();
    handleSend();
  }
});


/* ============================================
   UI HELPERS
   ============================================ */
function hideWelcome() {
  const w = document.getElementById("welcomeMsg");
  if (w) w.remove();
}

function addMessage(text, type) {
  const pane = document.getElementById("chatPane");
  const div  = document.createElement("div");
  div.className = "msg " + type;

  const avatarContent = type === "user"
    ? "U"
    : '<i class="ti ti-robot"></i>';

  div.innerHTML = `
    <div class="msg-avatar">${avatarContent}</div>
    <div class="msg-bubble">${escHtml(text)}</div>
  `;

  pane.appendChild(div);
  scrollDown();
}

function addImageMsg(url) {
  const pane = document.getElementById("chatPane");
  const div  = document.createElement("div");
  div.className = "msg bot";
  div.innerHTML = `
    <div class="msg-avatar"><i class="ti ti-robot"></i></div>
    <div class="msg-bubble">
      <img src="${url}" alt="Generated image" />
    </div>
  `;
  pane.appendChild(div);
  scrollDown();
}

function addTyping() {
  const pane = document.getElementById("chatPane");
  const div  = document.createElement("div");
  div.className = "msg bot";
  div.innerHTML = `
    <div class="msg-avatar"><i class="ti ti-robot"></i></div>
    <div class="msg-bubble">
      <div class="typing"><span></span><span></span><span></span></div>
    </div>
  `;
  pane.appendChild(div);
  scrollDown();
  return div;
}

function scrollDown() {
  const p = document.getElementById("chatPane");
  p.scrollTop = p.scrollHeight;
}

function escHtml(s) {
  return s
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
}


/* ============================================
   SIDEBAR HISTORY
   ============================================ */
function addToHistory(type, prompt, imgUrl) {
  sessionHistory.unshift({ type, prompt, imgUrl, time: new Date() });
  renderHistory();
}

function renderHistory() {
  const list  = document.getElementById("historyList");
  const empty = document.getElementById("emptyHist");
  if (empty) empty.remove();

  list.innerHTML = sessionHistory.map(function(item, i) {
    const mins    = Math.floor((Date.now() - item.time) / 60000);
    const timeStr = mins < 1 ? "just now" : mins + "m ago";

    const iconClass = item.type === "chat"
      ? "ti ti-message-circle"
      : "ti ti-photo";

    return `
      <div class="hist-item" onclick="loadHistory(${i})">
        <i class="${iconClass} hist-icon"></i>
        <div class="hist-text">
          <div class="hist-prompt">${escHtml(item.prompt)}</div>
          <div class="hist-meta">
            <span class="hist-badge ${item.type}">${item.type}</span>
            ${timeStr}
          </div>
        </div>
      </div>
    `;
  }).join("");
}

function loadHistory(i) {
  const item = sessionHistory[i];
  hideWelcome();

  const pane = document.getElementById("chatPane");
  pane.innerHTML = "";

  addMessage(item.prompt, "user");

  if (item.type === "image" && item.imgUrl) {
    addImageMsg(item.imgUrl);
  } else {
    addMessage("(Loaded from history)", "bot");
  }

  document.querySelectorAll(".hist-item").forEach(function(el, idx) {
    el.classList.toggle("active", idx === i);
  });
}

function clearHistory() {
  sessionHistory = [];
  chatHistory    = [];
  document.getElementById("historyList").innerHTML = `
    <div class="empty-hist" id="emptyHist">
      <i class="ti ti-history"></i>
      Your conversations will appear here
    </div>
  `;
}


/* ============================================
   CHAT API
   ============================================ */
async function sendChat() {
  try {
    const res = await fetch(
      "https://api.fireworks.ai/inference/v1/chat/completions",
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": "Bearer " + API_KEY
        },
        body: JSON.stringify({
          model: "accounts/fireworks/models/llama-v3p1-8b-instruct",
          messages: chatHistory
        })
      }
    );

    const data = await res.json();
    return data?.choices?.[0]?.message?.content || "No response.";

  } catch (e) {
    console.error("Chat error:", e);
    return "Chat error: " + e.message;
  }
}


/* ============================================
   IMAGE API  ← THE FIX IS HERE
   ============================================
   The Fireworks image endpoint returns raw binary
   image bytes (JPEG/PNG), NOT a JSON body.
   Calling res.json() on binary data throws:
     SyntaxError: Unexpected token '�', "����..."
   Fix: check Content-Type first, then use
   res.blob() + URL.createObjectURL() for images.
   ============================================ */
async function sendImage(prompt) {
  try {
    const res = await fetch(
      "https://api.fireworks.ai/inference/v1/workflows/accounts/fireworks/models/flux-1-schnell-fp8/text_to_image",
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "Authorization": "Bearer " + API_KEY
        },
        body: JSON.stringify({
          prompt: prompt,
          width:  1024,
          height: 1024
        })
      }
    );

    if (!res.ok) {
      const errText = await res.text();
      console.error("Image API error:", res.status, errText);
      return "";
    }

    const contentType = res.headers.get("content-type") || "";

    /* Case 1: API returned a JSON object with a URL inside */
    if (contentType.includes("application/json")) {
      const data = await res.json();
      return (
        data?.images?.[0]?.url ||
        data?.data?.[0]?.url   ||
        ""
      );
    }

    /* Case 2: API returned raw image bytes — the common case */
    const blob = await res.blob();
    return URL.createObjectURL(blob);

  } catch (e) {
    console.error("Image error:", e);
    return "";
  }
}
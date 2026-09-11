function setCookie(cookieName, cookieValue, expiryDate) {
  if (!cookieName || typeof cookieName !== "string") {
    throw new Error("Cookie name  must be non-empty strings.");
  }
  if (!cookieValue || typeof cookieValue !== "string") {
    throw new Error("Cookie value must be a non-empty string.");
  }
  let cookie =
    encodeURIComponent(cookieName) + "=" + encodeURIComponent(cookieValue);
  if (expiryDate !== undefined) {
    if (!(expiryDate instanceof Date))
      throw new Error("Expiry date must be Date object");

    cookie += "; expires=" + expiryDate.toUTCString();
  }

  cookie += "; path=/";
  document.cookie = cookie;
}
function getCookie(cookieName) {
  if (!cookieName || typeof cookieName !== "string") {
    throw new Error(
      "Invalid cookie name. Cookie name must be a non-empty string.",
    );
  }
  var cookies = document.cookie ? document.cookie.split("; ") : [];
  for (var i = 0; i < cookies.length; i++) {
    var cookie = cookies[i].split("=");
    if (decodeURIComponent(cookie[0]) === cookieName) {
      return decodeURIComponent(cookie[1]);
    }
  }
  return null;
}
function deleteCookie(cookieName) {
  if (!cookieName || typeof cookieName !== "string") {
    throw new Error(
      "Invalid cookie name. Cookie name must be a non-empty string.",
    );
  }
  var expiredate = new Date();
  expiredate.setTime(expiredate.getTime() - 1);
  document.cookie =
    cookieName + "=; expires=" + expiredate.toUTCString() + "; path=/";
}
function listCookies() {
  var cookies = document.cookie ? document.cookie.split("; ") : [];
  var cookieList = [];
  for (var i = 0; i < cookies.length; i++) {
    var cookie = cookies[i].split("=");
    cookieList.push({
      name: decodeURIComponent(cookie[0]),
      value: decodeURIComponent(cookie[1]),
    });
  }
  return cookieList;
}
function hasCookie(cookieName) {
  if (!cookieName || typeof cookieName !== "string")
    throw new Error("Invalid cookie name");
  return getCookie(cookieName) !== null;
}

const tabs = document.getElementById("tabs");
const postsContainer = document.getElementById("posts");

// users
function getUsers() {
    fetch("https://jsonplaceholder.typicode.com/users")
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to fetch users");
            }
            return response.json();
        })
        .then(users => {
            users.forEach(user => {
                const btn = document.createElement("button");
                btn.textContent = user.name;

                btn.onclick = () => getPosts(user.id);

                tabs.appendChild(btn);
            });
        })
        .catch(error => {
            console.error("Error:", error);
            tabs.innerHTML = "<p>Failed to load users</p>";
        });
}

// posts
async function getPosts(userId) {
    const res = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${userId}`);
    const posts = await res.json();

    postsContainer.innerHTML = "";

    posts.forEach(post => {
        const div = document.createElement("div");
        div.innerHTML = `<h4>${post.title}</h4><p>${post.body}</p>`;
        postsContainer.appendChild(div);
    });
}

getUsers();
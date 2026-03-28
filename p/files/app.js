// ===== app.js — Main Application Logic =====

/**
 * A to Z Academy — Main App
 * Initializes global functionality across all pages
 */

const App = {
  init() {
    this.updateNavCartCount();
    this.handleNavbarScroll();
    this.updateNavUserState();
  },

  /** Update cart count badge in navbar */
  updateNavCartCount() {
    const cart = JSON.parse(localStorage.getItem('atoz_cart') || '[]');
    const badges = document.querySelectorAll('[data-cart-count]');
    badges.forEach(badge => {
      badge.textContent = cart.length;
      badge.style.display = cart.length > 0 ? 'flex' : 'none';
    });
  },

  /** Navbar scroll sticky effect */
  handleNavbarScroll() {
    const navbar = document.getElementById('navbar');
    if (!navbar) return;
    window.addEventListener('scroll', () => {
      if (window.scrollY > 40) navbar.classList.add('scrolled');
      else navbar.classList.remove('scrolled');
    }, { passive: true });
  },

  /** Update navbar based on login state */
  updateNavUserState() {
    const user = JSON.parse(localStorage.getItem('atoz_current_user') || 'null');
    const loginBtns = document.querySelectorAll('[data-login-btn]');
    const logoutBtns = document.querySelectorAll('[data-logout-btn]');
    const userNames = document.querySelectorAll('[data-user-name]');

    if (user) {
      loginBtns.forEach(el => el.style.display = 'none');
      logoutBtns.forEach(el => el.style.display = 'flex');
      userNames.forEach(el => el.textContent = user.fullname);
    } else {
      loginBtns.forEach(el => el.style.display = 'flex');
      logoutBtns.forEach(el => el.style.display = 'none');
    }
  },

  /** Logout helper */
  logout() {
    localStorage.removeItem('atoz_current_user');
    if (typeof showToast === 'function') showToast('تم تسجيل الخروج', 'info');
    setTimeout(() => window.location.href = 'index.html', 800);
  },
};

// Auto-init on DOM ready
document.addEventListener('DOMContentLoaded', () => App.init());

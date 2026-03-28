// ===== ui.js — Toast & UI Utilities =====

/**
 * Show a toast notification
 * @param {string} message
 * @param {'success'|'error'|'info'|'warning'} type
 * @param {number} duration
 */
function showToast(message, type = 'success', duration = 3500) {
  let toast = document.getElementById('global-toast');
  if (!toast) {
    toast = document.createElement('div');
    toast.id = 'global-toast';
    toast.style.cssText = `
      position:fixed;top:24px;right:24px;z-index:99999;
      min-width:280px;max-width:400px;
      padding:1rem 1.5rem;border-radius:14px;
      font-weight:600;font-size:0.9rem;
      display:none;align-items:center;gap:0.75rem;
      box-shadow:0 8px 30px rgba(0,0,0,0.15);
      font-family:'Cairo',sans-serif;
      transition: all 0.3s ease;
    `;
    document.body.appendChild(toast);
  }

  const styles = {
    success: 'background:#fff;border-right:4px solid #10b981;color:#065f46;',
    error:   'background:#fff;border-right:4px solid #ef4444;color:#991b1b;',
    info:    'background:#fff;border-right:4px solid #0075AF;color:#0075AF;',
    warning: 'background:#fff;border-right:4px solid #f59e0b;color:#92400e;',
  };
  const icons = { success:'✅', error:'❌', info:'ℹ️', warning:'⚠️' };

  toast.style.cssText += styles[type] || styles.info;
  toast.style.display = 'flex';
  toast.innerHTML = `<span style="font-size:1.1rem;">${icons[type]}</span><span>${message}</span>`;

  clearTimeout(toast._timer);
  toast._timer = setTimeout(() => {
    toast.style.opacity = '0';
    setTimeout(() => { toast.style.display = 'none'; toast.style.opacity = '1'; }, 300);
  }, duration);
}

/**
 * Format price in Arabic
 */
function formatPrice(amount) {
  return `${amount.toLocaleString('ar-EG')} جنيه`;
}

/**
 * Animate elements on scroll
 */
function initScrollAnimations() {
  const observer = new IntersectionObserver((entries) => {
    entries.forEach((entry, i) => {
      if (entry.isIntersecting) {
        setTimeout(() => entry.target.classList.add('visible'), i * 80);
      }
    });
  }, { threshold: 0.08 });

  document.querySelectorAll('.animate-on-scroll').forEach(el => observer.observe(el));
}

/**
 * Smooth scroll to section
 */
function scrollToSection(id) {
  const el = document.getElementById(id);
  if (el) el.scrollIntoView({ behavior: 'smooth', block: 'start' });
}

// Initialize scroll animations on DOM ready
document.addEventListener('DOMContentLoaded', initScrollAnimations);

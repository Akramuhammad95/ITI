// ===== auth.js — Authentication Logic =====

const AUTH_KEYS = {
  USERS: 'atoz_users',
  CURRENT: 'atoz_current_user',
};

const Auth = {
  /**
   * Register a new user
   * @returns {{ success: boolean, message: string, user?: object }}
   */
  register({ fullname, email, password, ageGroup }) {
    const users = this.getAllUsers();

    if (users.find(u => u.email === email)) {
      return { success: false, message: 'البريد الإلكتروني مسجل بالفعل!' };
    }

    if (password.length < 8) {
      return { success: false, message: 'كلمة المرور يجب أن تكون 8 أحرف على الأقل' };
    }

    const newUser = {
      id: Date.now().toString(),
      fullname: fullname.trim(),
      email: email.trim().toLowerCase(),
      password,
      ageGroup,
      createdAt: new Date().toISOString(),
    };

    users.push(newUser);
    localStorage.setItem(AUTH_KEYS.USERS, JSON.stringify(users));
    this.setCurrentUser(newUser);
    return { success: true, message: 'تم إنشاء الحساب بنجاح!', user: newUser };
  },

  /**
   * Login existing user
   * @returns {{ success: boolean, message: string, user?: object }}
   */
  login(email, password) {
    const users = this.getAllUsers();
    const user = users.find(
      u => u.email === email.trim().toLowerCase() && u.password === password
    );

    if (!user) {
      return { success: false, message: 'البريد الإلكتروني أو كلمة المرور غير صحيحة' };
    }

    this.setCurrentUser(user);
    return { success: true, message: 'تم تسجيل الدخول بنجاح!', user };
  },

  /** Logout current user */
  logout() {
    localStorage.removeItem(AUTH_KEYS.CURRENT);
  },

  /** Get current logged-in user */
  getCurrentUser() {
    return JSON.parse(localStorage.getItem(AUTH_KEYS.CURRENT) || 'null');
  },

  /** Set current user in localStorage */
  setCurrentUser(user) {
    localStorage.setItem(AUTH_KEYS.CURRENT, JSON.stringify(user));
  },

  /** Get all registered users */
  getAllUsers() {
    return JSON.parse(localStorage.getItem(AUTH_KEYS.USERS) || '[]');
  },

  /** Check if user is logged in */
  isLoggedIn() {
    return !!this.getCurrentUser();
  },

  /**
   * Require authentication — redirect to login if not logged in
   * @param {string} redirectUrl
   */
  requireAuth(redirectUrl = 'login.html') {
    if (!this.isLoggedIn()) {
      window.location.href = redirectUrl;
      return false;
    }
    return true;
  },
};

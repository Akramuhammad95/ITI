// ===== cart.js — Cart Logic =====

const CART_KEY = 'atoz_cart';
const SOFT_DISCOUNT_RATE = 0.5;

const Cart = {
  /** Get all cart items */
  getItems() {
    return JSON.parse(localStorage.getItem(CART_KEY) || '[]');
  },

  /** Save items to localStorage */
  _save(items) {
    localStorage.setItem(CART_KEY, JSON.stringify(items));
  },

  /** Add course to cart */
  addItem(course) {
    const items = this.getItems();
    if (items.find(c => c.id === course.id)) {
      return { success: false, message: 'الكورس موجود في السلة بالفعل!' };
    }
    items.push(course);
    this._save(items);
    return { success: true, message: `تم إضافة "${course.name}" للسلة` };
  },

  /** Remove course from cart by id */
  removeItem(courseId) {
    const items = this.getItems().filter(c => c.id !== courseId);
    this._save(items);
    return { success: true };
  },

  /** Clear entire cart */
  clear() {
    localStorage.removeItem(CART_KEY);
  },

  /** Check if item is in cart */
  hasItem(courseId) {
    return this.getItems().some(c => c.id === courseId);
  },

  /** Get cart count */
  count() {
    return this.getItems().length;
  },

  /**
   * Calculate pricing with discount logic:
   * If cart has Soft Skills + any other course → 50% off all Soft Skills
   * @returns {{ subTotal, discountAmount, grandTotal, hasDiscount, softItems }}
   */
  calcPricing() {
    const items = this.getItems();
    const hasSoft = items.some(c => c.isSoft);
    const hasRegular = items.some(c => !c.isSoft);
    const hasDiscount = hasSoft && hasRegular;

    const softItems = items.filter(c => c.isSoft);
    const softOrigTotal = softItems.reduce((sum, c) => sum + c.price, 0);
    const discountAmount = hasDiscount ? Math.round(softOrigTotal * SOFT_DISCOUNT_RATE) : 0;
    const subTotal = items.reduce((sum, c) => sum + c.price, 0);
    const grandTotal = subTotal - discountAmount;

    return {
      subTotal,
      discountAmount,
      grandTotal,
      hasDiscount,
      softItems,
      itemCount: items.length,
    };
  },

  /**
   * Get effective price of a single item considering discount
   */
  getEffectivePrice(course) {
    const { hasDiscount } = this.calcPricing();
    if (course.isSoft && hasDiscount) {
      return Math.round(course.price * SOFT_DISCOUNT_RATE);
    }
    return course.price;
  },
};

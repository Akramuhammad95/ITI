import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-newsletter',
  standalone: true,
  imports: [FormsModule, CommonModule],
  template: `
    <section class="newsletter">
      <div class="nl-inner">
        <div class="nl-card">
          <div class="nl-bg">
            <div class="nl-orb nl-orb-1"></div>
            <div class="nl-orb nl-orb-2"></div>
          </div>
          <div class="nl-content">
            <div class="nl-badge">📬 Weekly Digest</div>
            <h2>Engineering insights, zero noise.</h2>
            <p>
              Every Friday, a curated digest of the 10 articles every serious developer
              should read. Trusted by 180,000+ engineers worldwide.
            </p>
            <div class="nl-form" *ngIf="!submitted()">
              <input
                type="email"
                placeholder="your@email.com"
                [(ngModel)]="email"
              />
              <button (click)="submit()">Subscribe free →</button>
            </div>
            <div class="nl-success" *ngIf="submitted()">
              <span class="check">✓</span>
              You're in! Check your inbox to confirm.
            </div>
            <p class="nl-fine">No spam. Unsubscribe anytime. Read by teams at Google, Stripe &amp; Vercel.</p>
          </div>
        </div>
      </div>
    </section>
  `,
  styles: [`
    .newsletter { padding: 2rem 2rem 6rem; }
    .nl-inner { max-width: 1280px; margin: 0 auto; }
    .nl-card {
      position: relative; overflow: hidden;
      border-radius: 28px;
      border: 1px solid rgba(110,231,247,0.2);
      background: linear-gradient(135deg, rgba(110,231,247,0.05), rgba(129,140,248,0.07));
      padding: 5rem 4rem; text-align: center;
    }
    .nl-bg { position: absolute; inset: 0; pointer-events: none; }
    .nl-orb {
      position: absolute; border-radius: 50%; filter: blur(80px); opacity: 0.2;
    }
    .nl-orb-1 {
      width: 400px; height: 400px; top: -100px; left: -100px;
      background: radial-gradient(circle, #6ee7f7, transparent 70%);
    }
    .nl-orb-2 {
      width: 350px; height: 350px; bottom: -80px; right: -80px;
      background: radial-gradient(circle, #818cf8, transparent 70%);
    }
    .nl-content { position: relative; max-width: 560px; margin: 0 auto; }
    .nl-badge {
      display: inline-block; background: rgba(110,231,247,0.1);
      border: 1px solid rgba(110,231,247,0.25); color: #6ee7f7;
      border-radius: 999px; padding: 0.3rem 0.9rem;
      font-size: 0.8rem; font-family: 'DM Sans', sans-serif;
      font-weight: 600; margin-bottom: 1.25rem;
    }
    .nl-content h2 {
      font-family: 'Syne', sans-serif; font-weight: 800;
      font-size: 2.5rem; color: #fff; letter-spacing: -0.04em;
      margin: 0 0 1rem;
    }
    .nl-content > p {
      color: rgba(255,255,255,0.5); font-family: 'DM Sans', sans-serif;
      font-size: 1rem; line-height: 1.7; margin: 0 0 2rem;
    }
    .nl-form {
      display: flex; gap: 0.5rem; max-width: 440px; margin: 0 auto 1rem;
    }
    .nl-form input {
      flex: 1; background: rgba(255,255,255,0.07);
      border: 1px solid rgba(255,255,255,0.15);
      color: #fff; border-radius: 12px; padding: 0.85rem 1.1rem;
      font-size: 0.95rem; outline: none; font-family: 'DM Sans', sans-serif;
      transition: border-color 0.2s;
    }
    .nl-form input:focus { border-color: rgba(110,231,247,0.4); }
    .nl-form input::placeholder { color: rgba(255,255,255,0.3); }
    .nl-form button {
      background: linear-gradient(135deg, #6ee7f7, #818cf8);
      border: none; color: #080810; border-radius: 12px;
      padding: 0.85rem 1.5rem; font-size: 0.95rem; cursor: pointer;
      font-weight: 700; white-space: nowrap; font-family: 'Syne', sans-serif;
      transition: opacity 0.2s;
    }
    .nl-form button:hover { opacity: 0.88; }
    .nl-success {
      display: flex; align-items: center; justify-content: center; gap: 0.75rem;
      background: rgba(52,211,153,0.1); border: 1px solid rgba(52,211,153,0.3);
      color: #34d399; border-radius: 12px; padding: 1rem 1.5rem;
      font-family: 'DM Sans', sans-serif; font-weight: 600;
      max-width: 440px; margin: 0 auto 1rem;
    }
    .check {
      background: #34d399; color: #080810; width: 22px; height: 22px;
      border-radius: 50%; display: flex; align-items: center;
      justify-content: center; font-size: 0.8rem; font-weight: 800;
    }
    .nl-fine {
      color: rgba(255,255,255,0.3) !important; font-size: 0.8rem !important;
      margin: 0 !important;
    }
  `],
})
export class NewsletterComponent {
  email = '';
  submitted = signal(false);
  submit() { if (this.email) this.submitted.set(true); }
}

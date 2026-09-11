import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  template: `
    <footer class="footer">
      <div class="footer-inner">
        <div class="footer-top">
          <div class="footer-brand">
            <a class="brand" href="#">
              <span class="brand-icon">⬡</span>
              <span class="brand-name">devpulse</span>
            </a>
            <p>The developer news platform built by engineers, for engineers. Stay sharp, stay relevant.</p>
            <div class="socials">
              <a href="#" *ngFor="let s of socials" class="social-btn" [title]="s.name">{{ s.icon }}</a>
            </div>
          </div>
          <div class="footer-links">
            <div class="link-col" *ngFor="let col of linkCols">
              <h4>{{ col.heading }}</h4>
              <ul>
                <li *ngFor="let link of col.links">
                  <a [href]="link.href">{{ link.label }}</a>
                </li>
              </ul>
            </div>
          </div>
        </div>
        <div class="footer-bottom">
          <span>© 2025 DevPulse, Inc. All rights reserved.</span>
          <div class="bottom-links">
            <a href="#">Privacy Policy</a>
            <a href="#">Terms of Service</a>
            <a href="#">Cookie Settings</a>
          </div>
        </div>
      </div>
    </footer>
  `,
  styles: [`
    .footer {
      border-top: 1px solid rgba(255,255,255,0.07);
      padding: 4rem 2rem 2rem;
    }
    .footer-inner { max-width: 1280px; margin: 0 auto; }
    .footer-top { display: grid; grid-template-columns: 1.5fr 2fr; gap: 4rem; margin-bottom: 3rem; }
    .brand {
      display: flex; align-items: center; gap: 0.5rem;
      text-decoration: none; color: #fff; margin-bottom: 1rem;
    }
    .brand-icon { font-size: 1.4rem; color: #6ee7f7; }
    .brand-name {
      font-family: 'Syne', sans-serif; font-weight: 800;
      font-size: 1.25rem; letter-spacing: -0.03em;
    }
    .footer-brand p {
      color: rgba(255,255,255,0.4); font-family: 'DM Sans', sans-serif;
      font-size: 0.9rem; line-height: 1.7; max-width: 280px; margin: 0 0 1.5rem;
    }
    .socials { display: flex; gap: 0.5rem; }
    .social-btn {
      display: flex; align-items: center; justify-content: center;
      width: 38px; height: 38px;
      background: rgba(255,255,255,0.05); border: 1px solid rgba(255,255,255,0.1);
      border-radius: 10px; text-decoration: none; font-size: 1rem;
      transition: all 0.2s;
    }
    .social-btn:hover { background: rgba(255,255,255,0.1); border-color: rgba(255,255,255,0.2); }
    .footer-links { display: grid; grid-template-columns: repeat(3, 1fr); gap: 2rem; }
    .link-col h4 {
      font-family: 'Syne', sans-serif; font-weight: 700;
      font-size: 0.875rem; color: #fff; margin: 0 0 1rem;
      letter-spacing: -0.01em;
    }
    .link-col ul { list-style: none; margin: 0; padding: 0; display: flex; flex-direction: column; gap: 0.6rem; }
    .link-col a {
      text-decoration: none; color: rgba(255,255,255,0.4);
      font-family: 'DM Sans', sans-serif; font-size: 0.875rem;
      transition: color 0.2s;
    }
    .link-col a:hover { color: #fff; }
    .footer-bottom {
      display: flex; align-items: center; justify-content: space-between;
      padding-top: 2rem; border-top: 1px solid rgba(255,255,255,0.07);
      color: rgba(255,255,255,0.3); font-family: 'DM Sans', sans-serif; font-size: 0.82rem;
    }
    .bottom-links { display: flex; gap: 1.5rem; }
    .bottom-links a {
      text-decoration: none; color: rgba(255,255,255,0.3);
      transition: color 0.2s; font-size: 0.82rem;
    }
    .bottom-links a:hover { color: rgba(255,255,255,0.6); }
    @media (max-width: 768px) {
      .footer-top { grid-template-columns: 1fr; gap: 2rem; }
      .footer-links { grid-template-columns: repeat(2, 1fr); }
    }
  `],
})
export class FooterComponent {
  socials = [
    { name: 'X / Twitter', icon: '𝕏' },
    { name: 'GitHub', icon: '⌥' },
    { name: 'Discord', icon: '◈' },
    { name: 'RSS', icon: '◉' },
  ];

  linkCols = [
    {
      heading: 'Product',
      links: [
        { label: 'Feed', href: '#' },
        { label: 'Squads', href: '#' },
        { label: 'Bookmarks', href: '#' },
        { label: 'Daily Digest', href: '#' },
      ],
    },
    {
      heading: 'Developers',
      links: [
        { label: 'API Docs', href: '#' },
        { label: 'Changelog', href: '#' },
        { label: 'Status', href: '#' },
        { label: 'Open Source', href: '#' },
      ],
    },
    {
      heading: 'Company',
      links: [
        { label: 'About', href: '#' },
        { label: 'Blog', href: '#' },
        { label: 'Careers', href: '#' },
        { label: 'Contact', href: '#' },
      ],
    },
  ];
}

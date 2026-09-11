import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule],
  template: `
    <nav class="navbar" [class.scrolled]="scrolled()">
      <div class="nav-inner">
        <div class="nav-left">
          <a class="brand" href="#">
            <span class="brand-icon">⬡</span>
            <span class="brand-name">devpulse</span>
          </a>
          <ul class="nav-links">
            <li *ngFor="let link of navLinks">
              <a [href]="link.href" [class.active]="link.active">{{ link.label }}</a>
            </li>
          </ul>
        </div>
        <div class="nav-right">
          <div class="search-bar">
            <svg width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
              <circle cx="11" cy="11" r="8"/><path d="m21 21-4.35-4.35"/>
            </svg>
            <input type="text" placeholder="Search articles…" />
          </div>
          <button class="btn-ghost">Sign in</button>
          <button class="btn-primary">Get started</button>
        </div>
      </div>
    </nav>
  `,
  styles: [`
    .navbar {
      position: fixed; top: 0; left: 0; right: 0; z-index: 100;
      padding: 0 2rem;
      background: rgba(8, 8, 16, 0.6);
      backdrop-filter: blur(20px);
      border-bottom: 1px solid rgba(255,255,255,0.06);
      transition: background 0.3s;
    }
    .navbar.scrolled { background: rgba(8,8,16,0.92); }
    .nav-inner {
      max-width: 1280px; margin: 0 auto;
      display: flex; align-items: center; justify-content: space-between;
      height: 64px;
    }
    .nav-left { display: flex; align-items: center; gap: 2.5rem; }
    .brand {
      display: flex; align-items: center; gap: 0.5rem;
      text-decoration: none; color: #fff;
    }
    .brand-icon { font-size: 1.4rem; color: #6ee7f7; }
    .brand-name {
      font-family: 'Syne', sans-serif; font-weight: 800;
      font-size: 1.25rem; letter-spacing: -0.03em;
    }
    .nav-links {
      display: flex; gap: 0.25rem; list-style: none; margin: 0; padding: 0;
    }
    .nav-links a {
      text-decoration: none; color: rgba(255,255,255,0.55);
      font-size: 0.875rem; font-weight: 500; padding: 0.4rem 0.75rem;
      border-radius: 8px; transition: all 0.2s;
      font-family: 'DM Sans', sans-serif;
    }
    .nav-links a:hover, .nav-links a.active {
      color: #fff; background: rgba(255,255,255,0.08);
    }
    .nav-right { display: flex; align-items: center; gap: 0.75rem; }
    .search-bar {
      display: flex; align-items: center; gap: 0.5rem;
      background: rgba(255,255,255,0.06); border: 1px solid rgba(255,255,255,0.1);
      border-radius: 10px; padding: 0.4rem 0.75rem;
    }
    .search-bar svg { color: rgba(255,255,255,0.35); flex-shrink: 0; }
    .search-bar input {
      background: none; border: none; outline: none;
      color: #fff; font-size: 0.85rem; width: 160px;
      font-family: 'DM Sans', sans-serif;
    }
    .search-bar input::placeholder { color: rgba(255,255,255,0.3); }
    .btn-ghost {
      background: none; border: 1px solid rgba(255,255,255,0.15);
      color: rgba(255,255,255,0.7); border-radius: 10px;
      padding: 0.45rem 1rem; font-size: 0.85rem; cursor: pointer;
      transition: all 0.2s; font-family: 'DM Sans', sans-serif; font-weight: 500;
    }
    .btn-ghost:hover { border-color: rgba(255,255,255,0.3); color: #fff; }
    .btn-primary {
      background: linear-gradient(135deg, #6ee7f7, #818cf8);
      border: none; color: #080810; border-radius: 10px;
      padding: 0.45rem 1rem; font-size: 0.85rem; cursor: pointer;
      font-weight: 700; transition: opacity 0.2s;
      font-family: 'DM Sans', sans-serif;
    }
    .btn-primary:hover { opacity: 0.88; }
  `],
})
export class NavbarComponent {
  scrolled = signal(false);
  navLinks = [
    { label: 'Feed', href: '#', active: true },
    { label: 'Trending', href: '#', active: false },
    { label: 'Bookmarks', href: '#', active: false },
    { label: 'Squads', href: '#', active: false },
  ];
}

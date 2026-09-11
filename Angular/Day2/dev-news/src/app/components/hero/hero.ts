import { Component } from '@angular/core';

@Component({
  selector: 'app-hero',
  standalone: true,
  template: `
    <section class="hero">
      <div class="hero-bg">
        <div class="orb orb-1"></div>
        <div class="orb orb-2"></div>
        <div class="orb orb-3"></div>
        <div class="grid-lines"></div>
      </div>
      <div class="hero-inner">
        <div class="badge">
          <span class="badge-dot"></span>
          Curated for engineers · Updated hourly
        </div>
        <h1 class="hero-title">
          Where developers<br />
          <span class="gradient-text">stay ahead.</span>
        </h1>
        <p class="hero-sub">
          The smartest feed for software engineers. Discover, bookmark, and discuss<br />
          the articles that move the industry forward.
        </p>
        <div class="hero-cta">
          <button class="cta-main">Start reading free</button>
          <button class="cta-sec">
            <svg width="16" height="16" viewBox="0 0 24 24" fill="currentColor">
              <path d="M8 5v14l11-7z"/>
            </svg>
            See how it works
          </button>
        </div>
        <div class="hero-tags">
          <span *ngFor="let t of tags" class="tag">{{ t }}</span>
        </div>
      </div>
    </section>
  `,
  styles: [`
    .hero {
      position: relative; overflow: hidden;
      min-height: 100vh; display: flex; align-items: center;
      padding: 120px 2rem 80px;
    }
    .hero-bg {
      position: absolute; inset: 0; pointer-events: none;
    }
    .orb {
      position: absolute; border-radius: 50%;
      filter: blur(100px); opacity: 0.18;
    }
    .orb-1 {
      width: 600px; height: 600px; top: -150px; left: -100px;
      background: radial-gradient(circle, #6ee7f7, transparent 70%);
      animation: drift 12s ease-in-out infinite alternate;
    }
    .orb-2 {
      width: 500px; height: 500px; top: 100px; right: -80px;
      background: radial-gradient(circle, #818cf8, transparent 70%);
      animation: drift 16s ease-in-out infinite alternate-reverse;
    }
    .orb-3 {
      width: 400px; height: 400px; bottom: 0; left: 40%;
      background: radial-gradient(circle, #f472b6, transparent 70%);
      animation: drift 20s ease-in-out infinite alternate;
    }
    @keyframes drift {
      from { transform: translate(0, 0) scale(1); }
      to { transform: translate(40px, 30px) scale(1.08); }
    }
    .grid-lines {
      position: absolute; inset: 0;
      background-image:
        linear-gradient(rgba(255,255,255,0.03) 1px, transparent 1px),
        linear-gradient(90deg, rgba(255,255,255,0.03) 1px, transparent 1px);
      background-size: 60px 60px;
    }
    .hero-inner {
      position: relative; max-width: 1280px; margin: 0 auto;
      display: flex; flex-direction: column; align-items: center;
      text-align: center; gap: 1.5rem;
    }
    .badge {
      display: inline-flex; align-items: center; gap: 0.5rem;
      background: rgba(110,231,247,0.08); border: 1px solid rgba(110,231,247,0.25);
      color: #6ee7f7; border-radius: 999px;
      padding: 0.35rem 1rem; font-size: 0.8rem; font-weight: 500;
      font-family: 'DM Sans', sans-serif;
    }
    .badge-dot {
      width: 6px; height: 6px; border-radius: 50%;
      background: #6ee7f7;
      box-shadow: 0 0 8px #6ee7f7;
      animation: pulse 2s infinite;
    }
    @keyframes pulse {
      0%, 100% { opacity: 1; }
      50% { opacity: 0.4; }
    }
    .hero-title {
      font-family: 'Syne', sans-serif; font-weight: 800;
      font-size: clamp(2.5rem, 6vw, 5rem);
      line-height: 1.05; letter-spacing: -0.04em;
      color: #fff; margin: 0;
    }
    .gradient-text {
      background: linear-gradient(135deg, #6ee7f7 0%, #818cf8 50%, #f472b6 100%);
      -webkit-background-clip: text; -webkit-text-fill-color: transparent;
      background-clip: text;
    }
    .hero-sub {
      color: rgba(255,255,255,0.5); font-size: 1.1rem;
      line-height: 1.7; max-width: 560px; margin: 0;
      font-family: 'DM Sans', sans-serif;
    }
    .hero-cta {
      display: flex; gap: 1rem; align-items: center;
    }
    .cta-main {
      background: linear-gradient(135deg, #6ee7f7, #818cf8);
      border: none; color: #080810; border-radius: 12px;
      padding: 0.85rem 2rem; font-size: 1rem; cursor: pointer;
      font-weight: 700; font-family: 'Syne', sans-serif;
      transition: transform 0.2s, box-shadow 0.2s;
      box-shadow: 0 0 40px rgba(110,231,247,0.25);
    }
    .cta-main:hover { transform: translateY(-2px); box-shadow: 0 8px 40px rgba(110,231,247,0.35); }
    .cta-sec {
      display: flex; align-items: center; gap: 0.5rem;
      background: rgba(255,255,255,0.06); border: 1px solid rgba(255,255,255,0.12);
      color: rgba(255,255,255,0.7); border-radius: 12px;
      padding: 0.85rem 1.5rem; font-size: 1rem; cursor: pointer;
      font-family: 'DM Sans', sans-serif; font-weight: 500;
      transition: all 0.2s;
    }
    .cta-sec:hover { background: rgba(255,255,255,0.1); color: #fff; }
    .hero-tags {
      display: flex; flex-wrap: wrap; gap: 0.5rem;
      justify-content: center; margin-top: 0.5rem;
    }
    .tag {
      background: rgba(255,255,255,0.05); border: 1px solid rgba(255,255,255,0.1);
      color: rgba(255,255,255,0.45); border-radius: 999px;
      padding: 0.25rem 0.75rem; font-size: 0.78rem;
      font-family: 'DM Mono', monospace;
    }
  `],
})
export class HeroComponent {
  tags = ['#typescript', '#rust', '#systemdesign', '#ai', '#devops', '#webperf', '#golang', '#react'];
}

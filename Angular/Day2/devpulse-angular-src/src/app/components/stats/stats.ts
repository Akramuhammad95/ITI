import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Stat {
  value: string;
  label: string;
  icon: string;
  color: string;
}

@Component({
  selector: 'app-stats',
  standalone: true,
  imports: [CommonModule],
  template: `
    <section class="stats">
      <div class="stats-inner">
        <div class="stat-card" *ngFor="let stat of stats">
          <div class="stat-icon" [style.color]="stat.color">{{ stat.icon }}</div>
          <div class="stat-value" [style.color]="stat.color">{{ stat.value }}</div>
          <div class="stat-label">{{ stat.label }}</div>
          <div class="stat-glow" [style.background]="stat.color"></div>
        </div>
      </div>
    </section>
  `,
  styles: [`
    .stats {
      padding: 0 2rem 6rem;
    }
    .stats-inner {
      max-width: 1280px; margin: 0 auto;
      display: grid; grid-template-columns: repeat(4, 1fr); gap: 1.5rem;
    }
    .stat-card {
      position: relative; overflow: hidden;
      background: rgba(255,255,255,0.03);
      border: 1px solid rgba(255,255,255,0.08);
      border-radius: 20px; padding: 2rem;
      text-align: center; transition: transform 0.3s, border-color 0.3s;
    }
    .stat-card:hover {
      transform: translateY(-4px);
      border-color: rgba(255,255,255,0.15);
    }
    .stat-icon { font-size: 1.8rem; margin-bottom: 0.75rem; }
    .stat-value {
      font-family: 'Syne', sans-serif; font-weight: 800;
      font-size: 2.25rem; letter-spacing: -0.04em;
      margin-bottom: 0.25rem;
    }
    .stat-label {
      color: rgba(255,255,255,0.45); font-size: 0.875rem;
      font-family: 'DM Sans', sans-serif;
    }
    .stat-glow {
      position: absolute; bottom: -40px; left: 50%;
      transform: translateX(-50%);
      width: 100px; height: 80px;
      border-radius: 50%; filter: blur(40px); opacity: 0.15;
    }
    @media (max-width: 768px) {
      .stats-inner { grid-template-columns: repeat(2, 1fr); }
    }
  `],
})
export class StatsComponent {
  stats: Stat[] = [
    { value: '4.2M', label: 'Active developers', icon: '👥', color: '#6ee7f7' },
    { value: '18K', label: 'Articles curated daily', icon: '📄', color: '#818cf8' },
    { value: '920+', label: 'Tech sources indexed', icon: '🔗', color: '#f472b6' },
    { value: '99ms', label: 'Average feed load', icon: '⚡', color: '#34d399' },
  ];
}

import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Category {
  id: string;
  name: string;
  icon: string;
  count: number;
  color: string;
}

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [CommonModule],
  template: `
    <section class="categories">
      <div class="categories-inner">
        <div class="section-header">
          <span class="section-tag">Topics</span>
          <h2>Explore by category</h2>
          <p>Dive deep into the areas you care about most</p>
        </div>
        <div class="category-grid">
          <div
            class="category-card"
            *ngFor="let cat of categories"
            [class.selected]="selectedId() === cat.id"
            (click)="select(cat.id)"
          >
            <div class="cat-icon" [style.background]="cat.color + '18'" [style.color]="cat.color">
              {{ cat.icon }}
            </div>
            <div class="cat-info">
              <span class="cat-name">{{ cat.name }}</span>
              <span class="cat-count">{{ cat.count | number }} articles</span>
            </div>
            <div class="cat-arrow" [style.color]="cat.color">›</div>
            <div class="cat-border" [style.background]="cat.color" [class.visible]="selectedId() === cat.id"></div>
          </div>
        </div>
      </div>
    </section>
  `,
  styles: [`
    .categories { padding: 2rem 2rem 6rem; }
    .categories-inner { max-width: 1280px; margin: 0 auto; }
    .section-header { text-align: center; margin-bottom: 3rem; }
    .section-tag {
      display: inline-block;
      font-family: 'DM Mono', monospace; font-size: 0.75rem;
      text-transform: uppercase; letter-spacing: 0.15em;
      color: #6ee7f7; margin-bottom: 0.75rem;
    }
    .section-header h2 {
      font-family: 'Syne', sans-serif; font-weight: 800;
      font-size: 2.5rem; color: #fff;
      letter-spacing: -0.04em; margin: 0 0 0.5rem;
    }
    .section-header p {
      color: rgba(255,255,255,0.4); font-family: 'DM Sans', sans-serif;
      font-size: 1rem; margin: 0;
    }
    .category-grid {
      display: grid; grid-template-columns: repeat(4, 1fr); gap: 1rem;
    }
    .category-card {
      position: relative; overflow: hidden;
      display: flex; align-items: center; gap: 0.75rem;
      background: rgba(255,255,255,0.03);
      border: 1px solid rgba(255,255,255,0.08);
      border-radius: 14px; padding: 1rem 1.25rem;
      cursor: pointer; transition: all 0.25s;
    }
    .category-card:hover, .category-card.selected {
      background: rgba(255,255,255,0.06);
      border-color: rgba(255,255,255,0.14);
      transform: translateY(-2px);
    }
    .cat-icon {
      width: 42px; height: 42px; border-radius: 12px;
      display: flex; align-items: center; justify-content: center;
      font-size: 1.2rem; flex-shrink: 0;
    }
    .cat-info {
      flex: 1; display: flex; flex-direction: column; gap: 0.15rem;
    }
    .cat-name {
      font-family: 'DM Sans', sans-serif; font-weight: 600;
      font-size: 0.9rem; color: #fff;
    }
    .cat-count {
      font-size: 0.75rem; color: rgba(255,255,255,0.35);
      font-family: 'DM Mono', monospace;
    }
    .cat-arrow {
      font-size: 1.3rem; transition: transform 0.2s;
    }
    .category-card:hover .cat-arrow { transform: translateX(3px); }
    .cat-border {
      position: absolute; bottom: 0; left: 0; right: 0;
      height: 2px; opacity: 0; transition: opacity 0.25s;
    }
    .cat-border.visible { opacity: 1; }
    @media (max-width: 900px) {
      .category-grid { grid-template-columns: repeat(2, 1fr); }
    }
  `],
})
export class CategoriesComponent {
  selectedId = signal<string>('typescript');

  select(id: string) { this.selectedId.set(id); }

  categories: Category[] = [
    { id: 'typescript', name: 'TypeScript', icon: '🔷', count: 14200, color: '#6ee7f7' },
    { id: 'ai', name: 'AI & ML', icon: '🤖', count: 22400, color: '#818cf8' },
    { id: 'devops', name: 'DevOps', icon: '🔧', count: 9800, color: '#34d399' },
    { id: 'system', name: 'System Design', icon: '🏗️', count: 7300, color: '#f472b6' },
    { id: 'rust', name: 'Rust', icon: '🦀', count: 5600, color: '#fb923c' },
    { id: 'webperf', name: 'Web Performance', icon: '⚡', count: 8100, color: '#facc15' },
    { id: 'security', name: 'Security', icon: '🔐', count: 11200, color: '#f87171' },
    { id: 'cloud', name: 'Cloud & Infra', icon: '☁️', count: 16400, color: '#a78bfa' },
  ];
}

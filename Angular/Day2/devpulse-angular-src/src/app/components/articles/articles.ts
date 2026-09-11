import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Article {
  id: number;
  title: string;
  summary: string;
  source: string;
  sourceIcon: string;
  author: string;
  readTime: number;
  tags: string[];
  upvotes: number;
  comments: number;
  badge?: string;
  badgeColor?: string;
  featured?: boolean;
}

@Component({
  selector: 'app-articles',
  standalone: true,
  imports: [CommonModule],
  template: `
    <section class="articles">
      <div class="articles-inner">
        <div class="section-header">
          <span class="section-tag">Feed</span>
          <h2>Today's top picks</h2>
          <p>Curated from 900+ engineering blogs and publications</p>
        </div>

        <div class="filter-row">
          <button
            *ngFor="let f of filters"
            class="filter-btn"
            [class.active]="activeFilter() === f"
            (click)="activeFilter.set(f)"
          >{{ f }}</button>
        </div>

        <div class="articles-grid">
          <article
            class="article-card"
            *ngFor="let article of articles; let i = index"
            [class.featured]="article.featured"
          >
            <div class="card-top">
              <div class="source-row">
                <span class="source-icon">{{ article.sourceIcon }}</span>
                <span class="source-name">{{ article.source }}</span>
                <span class="divider">·</span>
                <span class="read-time">{{ article.readTime }} min read</span>
                <span class="badge" *ngIf="article.badge" [style.color]="article.badgeColor" [style.borderColor]="article.badgeColor + '40'" [style.background]="article.badgeColor + '12'">
                  {{ article.badge }}
                </span>
              </div>
              <h3 class="article-title">{{ article.title }}</h3>
              <p class="article-summary">{{ article.summary }}</p>
            </div>
            <div class="card-bottom">
              <div class="tag-row">
                <span class="tag" *ngFor="let tag of article.tags">#{{ tag }}</span>
              </div>
              <div class="meta-row">
                <button class="upvote-btn" (click)="upvote(article)">
                  <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5">
                    <path d="m18 15-6-6-6 6"/>
                  </svg>
                  {{ article.upvotes }}
                </button>
                <button class="comment-btn">
                  <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                    <path d="M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"/>
                  </svg>
                  {{ article.comments }}
                </button>
                <button class="bookmark-btn">
                  <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                    <path d="m19 21-7-4-7 4V5a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2v16z"/>
                  </svg>
                </button>
              </div>
            </div>
          </article>
        </div>

        <div class="load-more">
          <button class="load-btn">Load more articles</button>
        </div>
      </div>
    </section>
  `,
  styles: [`
    .articles { padding: 2rem 2rem 6rem; }
    .articles-inner { max-width: 1280px; margin: 0 auto; }
    .section-header { text-align: center; margin-bottom: 2.5rem; }
    .section-tag {
      display: inline-block; font-family: 'DM Mono', monospace;
      font-size: 0.75rem; text-transform: uppercase; letter-spacing: 0.15em;
      color: #818cf8; margin-bottom: 0.75rem;
    }
    .section-header h2 {
      font-family: 'Syne', sans-serif; font-weight: 800;
      font-size: 2.5rem; color: #fff; letter-spacing: -0.04em; margin: 0 0 0.5rem;
    }
    .section-header p {
      color: rgba(255,255,255,0.4); font-family: 'DM Sans', sans-serif; font-size: 1rem; margin: 0;
    }
    .filter-row {
      display: flex; gap: 0.5rem; justify-content: center; margin-bottom: 2.5rem;
    }
    .filter-btn {
      background: rgba(255,255,255,0.04); border: 1px solid rgba(255,255,255,0.08);
      color: rgba(255,255,255,0.45); border-radius: 999px; padding: 0.4rem 1rem;
      font-size: 0.85rem; cursor: pointer; font-family: 'DM Sans', sans-serif;
      font-weight: 500; transition: all 0.2s;
    }
    .filter-btn:hover { color: #fff; border-color: rgba(255,255,255,0.2); }
    .filter-btn.active {
      background: rgba(129,140,248,0.15); border-color: rgba(129,140,248,0.4);
      color: #818cf8;
    }
    .articles-grid {
      display: grid; grid-template-columns: repeat(3, 1fr); gap: 1.25rem;
    }
    .article-card {
      display: flex; flex-direction: column; justify-content: space-between;
      background: rgba(255,255,255,0.03); border: 1px solid rgba(255,255,255,0.08);
      border-radius: 18px; padding: 1.5rem;
      transition: all 0.3s; cursor: pointer;
    }
    .article-card:hover {
      background: rgba(255,255,255,0.055);
      border-color: rgba(255,255,255,0.14);
      transform: translateY(-3px);
      box-shadow: 0 12px 40px rgba(0,0,0,0.3);
    }
    .article-card.featured {
      grid-column: span 2;
      background: linear-gradient(135deg, rgba(110,231,247,0.06), rgba(129,140,248,0.06));
      border-color: rgba(110,231,247,0.15);
    }
    .card-top { display: flex; flex-direction: column; gap: 0.75rem; flex: 1; }
    .source-row {
      display: flex; align-items: center; gap: 0.5rem;
      font-family: 'DM Sans', sans-serif; flex-wrap: wrap;
    }
    .source-icon { font-size: 1rem; }
    .source-name { font-size: 0.8rem; font-weight: 600; color: rgba(255,255,255,0.6); }
    .divider { color: rgba(255,255,255,0.25); font-size: 0.8rem; }
    .read-time { font-size: 0.78rem; color: rgba(255,255,255,0.35); }
    .badge {
      font-family: 'DM Mono', monospace; font-size: 0.7rem; font-weight: 600;
      border: 1px solid; border-radius: 999px; padding: 0.15rem 0.55rem;
      text-transform: uppercase; letter-spacing: 0.05em;
    }
    .article-title {
      font-family: 'Syne', sans-serif; font-weight: 700;
      font-size: 1.1rem; color: #fff; margin: 0;
      line-height: 1.4; letter-spacing: -0.02em;
    }
    .article-card.featured .article-title { font-size: 1.4rem; }
    .article-summary {
      font-family: 'DM Sans', sans-serif; font-size: 0.875rem;
      color: rgba(255,255,255,0.45); line-height: 1.6; margin: 0;
    }
    .card-bottom { margin-top: 1.25rem; display: flex; flex-direction: column; gap: 0.75rem; }
    .tag-row { display: flex; gap: 0.4rem; flex-wrap: wrap; }
    .tag {
      font-family: 'DM Mono', monospace; font-size: 0.72rem;
      color: rgba(255,255,255,0.3); background: rgba(255,255,255,0.05);
      border-radius: 5px; padding: 0.15rem 0.45rem;
    }
    .meta-row {
      display: flex; align-items: center; gap: 0.5rem;
    }
    .upvote-btn, .comment-btn, .bookmark-btn {
      display: flex; align-items: center; gap: 0.35rem;
      background: rgba(255,255,255,0.05); border: 1px solid rgba(255,255,255,0.08);
      color: rgba(255,255,255,0.45); border-radius: 8px;
      padding: 0.35rem 0.65rem; font-size: 0.8rem; cursor: pointer;
      font-family: 'DM Sans', sans-serif; transition: all 0.2s;
    }
    .upvote-btn:hover { background: rgba(110,231,247,0.1); color: #6ee7f7; border-color: rgba(110,231,247,0.3); }
    .comment-btn:hover { background: rgba(129,140,248,0.1); color: #818cf8; border-color: rgba(129,140,248,0.3); }
    .bookmark-btn:hover { background: rgba(244,114,182,0.1); color: #f472b6; border-color: rgba(244,114,182,0.3); }
    .load-more { display: flex; justify-content: center; margin-top: 3rem; }
    .load-btn {
      background: rgba(255,255,255,0.05); border: 1px solid rgba(255,255,255,0.12);
      color: rgba(255,255,255,0.6); border-radius: 12px;
      padding: 0.85rem 2.5rem; font-size: 0.95rem; cursor: pointer;
      font-family: 'DM Sans', sans-serif; font-weight: 500; transition: all 0.2s;
    }
    .load-btn:hover { background: rgba(255,255,255,0.09); color: #fff; }
    @media (max-width: 900px) {
      .articles-grid { grid-template-columns: 1fr; }
      .article-card.featured { grid-column: span 1; }
    }
  `],
})
export class ArticlesComponent {
  activeFilter = signal('Trending');
  filters = ['Trending', 'Latest', 'Most Discussed', 'Bookmarked'];

  upvote(article: Article) { article.upvotes++; }

  articles: Article[] = [
    {
      id: 1, featured: true,
      title: 'The Architecture Behind Linear\'s Blazing Fast UI: A Deep Dive',
      summary: 'Linear built one of the fastest UIs in SaaS by pushing rendering logic to the client and leveraging WebAssembly at critical paths. We explore their decisions and what you can steal for your own app.',
      source: 'Engineering at Linear', sourceIcon: '⬡', author: 'karri', readTime: 12,
      tags: ['performance', 'react', 'wasm'], upvotes: 2840, comments: 134,
      badge: 'Featured', badgeColor: '#6ee7f7',
    },
    {
      id: 2,
      title: 'TypeScript 5.6\'s New Satisfies Patterns Are Underrated',
      summary: 'Most engineers know about `satisfies` but don\'t use it to its full potential. Here\'s how to leverage it for zero-cost type narrowing.',
      source: 'Total TypeScript', sourceIcon: '🔷', author: 'mattpocock', readTime: 7,
      tags: ['typescript', 'types'], upvotes: 1420, comments: 67,
      badge: 'New', badgeColor: '#818cf8',
    },
    {
      id: 3,
      title: 'You Don\'t Need a Message Queue (Until You Do)',
      summary: 'A pragmatic take on when event-driven architecture adds genuine value vs. accidental complexity.',
      source: 'System Design Newsletter', sourceIcon: '🏗️', author: 'alex', readTime: 9,
      tags: ['systemdesign', 'kafka'], upvotes: 986, comments: 92,
    },
    {
      id: 4,
      title: 'Rust Error Handling in 2025: The Definitive Patterns Guide',
      summary: 'After years of anyhow vs thiserror debates, the community has converged on clear patterns. Here\'s the opinionated guide you\'ve been waiting for.',
      source: 'This Week in Rust', sourceIcon: '🦀', author: 'fasterthanlime', readTime: 15,
      tags: ['rust', 'errors'], upvotes: 1876, comments: 210,
      badge: 'Hot', badgeColor: '#f472b6',
    },
    {
      id: 5,
      title: 'Building Zero-Trust CI/CD Pipelines on Kubernetes',
      summary: 'How to enforce least-privilege across every step from commit to production deployment.',
      source: 'Cloud Native Weekly', sourceIcon: '☁️', author: 'tigersnow', readTime: 11,
      tags: ['devops', 'security', 'k8s'], upvotes: 743, comments: 45,
    },
    {
      id: 6,
      title: 'Local-First Software: The Promise and the Pain Points',
      summary: 'CRDTs, offline-first sync, and why building truly local-first apps is still harder than it should be in 2025.',
      source: 'Ink & Switch', sourceIcon: '✍️', author: 'pvh', readTime: 18,
      tags: ['localfirst', 'crdt'], upvotes: 2100, comments: 180,
      badge: 'Essay', badgeColor: '#34d399',
    },
  ];
}

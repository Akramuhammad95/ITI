import { Component } from '@angular/core';
import { NavbarComponent } from './components/navbar/navbar';
import { HeroComponent } from './components/hero/hero';
import { StatsComponent } from './components/stats/stats';
import { CategoriesComponent } from './components/categories/categories';
import { ArticlesComponent } from './components/articles/articles';
import { NewsletterComponent } from './components/newsletter/newsletter';
import { FooterComponent } from './components/footer/footer';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    NavbarComponent,
    HeroComponent,
    StatsComponent,
    CategoriesComponent,
    ArticlesComponent,
    NewsletterComponent,
    FooterComponent,
  ],
  template: `
    <app-navbar />
    <main>
      <app-hero />
      <app-stats />
      <app-categories />
      <app-articles />
      <app-newsletter />
    </main>
    <app-footer />
  `,
})
export class AppComponent {}

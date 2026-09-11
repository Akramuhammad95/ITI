import { Component } from '@angular/core';
import { Hero } from '../../components/hero/hero';
import { HomePosts } from '../../components/home-posts/home-posts';

@Component({
  selector: 'app-home',
  imports: [
    Hero,
    HomePosts
  ],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {

}
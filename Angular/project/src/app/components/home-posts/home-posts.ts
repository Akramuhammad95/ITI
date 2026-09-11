import { Component } from '@angular/core';
import { Postcard } from '../postcard/postcard';

@Component({
  selector: 'app-home-posts',
  imports: [Postcard],
  templateUrl: './home-posts.html',
  styleUrl: './home-posts.css'
})
export class HomePosts {

  posts = [
    {
      id:1,
      title:'The Future Of AI',
      category:'AI',
      image:'https://picsum.photos/500/300?1',
      description:'Discover how AI is changing web development.'
    },
    {
      id:2,
      title:'HTML Best Practices',
      category:'HTML',
      image:'https://picsum.photos/500/300?2',
      description:'Learn modern HTML techniques.'
    },
    {
      id:3,
      title:'Getting Started With React',
      category:'React',
      image:'https://picsum.photos/500/300?3',
      description:'Build modern applications with React.'
    }
  ];

}
import { Component } from '@angular/core';
import { Postcard } from '../postcard/postcard';

@Component({
  selector: 'app-postslist',
  imports: [Postcard],
  templateUrl: './postslist.html',
  styleUrl: './postslist.css'
})
export class Postslist {

  posts:any[] = [];

  ngOnInit(){

    const savedPosts =
      JSON.parse(localStorage.getItem('posts') || '[]');

    this.posts = [

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

      ...savedPosts

    ];
  }
}
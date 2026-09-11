import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-createpostmodal',
  imports: [FormsModule],
  templateUrl: './createpostmodal.html',
  styleUrl: './createpostmodal.css'
})
export class Createpostmodal {

  isOpen = signal(false);

  title = '';
  category = '';
  description = '';

  openModal(){
    this.isOpen.set(true);
  }

  closeModal(){
    this.isOpen.set(false);
  }

  savePost(){

    const posts =
      JSON.parse(localStorage.getItem('posts') || '[]');

    posts.push({
      id: Date.now(),
      title: this.title,
      category: this.category,
      description: this.description,
      image:'https://picsum.photos/500/300'
    });

    localStorage.setItem(
      'posts',
      JSON.stringify(posts)
    );

    this.closeModal();

    location.reload();
  }
}
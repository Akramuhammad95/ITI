import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {

  posts = [
    {
      title: 'Learn Angular',
      description: 'Modern Angular architecture, standalone components, signals and scalable frontend patterns.',
      image: 'https://picsum.photos/600/800?1'
    },

    {
      title: 'Backend Development',
      description: 'Build secure APIs, scalable systems, authentication and enterprise backend applications.',
      image: 'https://picsum.photos/600/800?2'
    },

    {
      title: 'System Design',
      description: 'Master distributed systems, microservices, caching, scalability and architecture patterns.',
      image: 'https://picsum.photos/600/800?3'
    }
  ];

}
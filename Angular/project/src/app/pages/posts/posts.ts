import { Component } from '@angular/core';
import { Postslist } from '../../components/postslist/postslist';
import { Createpostmodal } from '../../components/createpostmodal/createpostmodal';

@Component({
  selector: 'app-posts',
  imports: [
    Postslist,
    Createpostmodal
  ],
  templateUrl: './posts.html',
  styleUrl: './posts.css'
})
export class Posts {

}
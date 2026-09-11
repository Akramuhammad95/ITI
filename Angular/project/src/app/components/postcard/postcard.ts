import { Component, Input } from '@angular/core';
import { CategoryColor } from '../../directives/category-color';
import { HoverCard } from '../../directives/hover-card';
@Component({
  selector: 'app-postcard',
  imports: [
    CategoryColor,
    HoverCard
  ],
  templateUrl: './postcard.html',
  styleUrl: './postcard.css'
})
export class Postcard {

  @Input() post: any;

}
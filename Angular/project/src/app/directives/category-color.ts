import {
  Directive,
  ElementRef,
  Input,
  OnInit
} from '@angular/core';

@Directive({
  selector: '[appCategoryColor]'
})
export class CategoryColor implements OnInit {

  @Input() appCategoryColor = '';

  constructor(private el: ElementRef) {}

  ngOnInit() {

    switch (this.appCategoryColor) {

      case 'AI':
        this.el.nativeElement.style.background =
          '#8b5cf6';
        break;

      case 'React':
        this.el.nativeElement.style.background =
          '#06b6d4';
        break;

      case 'HTML':
        this.el.nativeElement.style.background =
          '#f97316';
        break;

      default:
        this.el.nativeElement.style.background =
          '#2563eb';
    }

    this.el.nativeElement.style.color = 'white';
    this.el.nativeElement.style.padding = '5px 10px';
    this.el.nativeElement.style.borderRadius = '20px';
  }
}
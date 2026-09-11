import {
  Directive,
  ElementRef,
  HostListener
} from '@angular/core';

@Directive({
  selector: '[appHoverCard]'
})
export class HoverCard {

  constructor(private el: ElementRef) {}

  @HostListener('mouseenter')
  onEnter() {

    this.el.nativeElement.style.transform =
      'translateY(-10px)';

    this.el.nativeElement.style.transition =
      '0.3s';

    this.el.nativeElement.style.boxShadow =
      '0 10px 25px rgba(0,0,0,.15)';
  }

  @HostListener('mouseleave')
  onLeave() {

    this.el.nativeElement.style.transform =
      'translateY(0)';

    this.el.nativeElement.style.boxShadow =
      '0 5px 15px rgba(0,0,0,.08)';
  }
}
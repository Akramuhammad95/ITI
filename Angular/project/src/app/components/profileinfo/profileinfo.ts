import { Component } from '@angular/core';

@Component({
  selector: 'app-profileinfo',
  imports: [],
  templateUrl: './profileinfo.html',
  styleUrl: './profileinfo.css'
})
export class Profileinfo {

  user:any;

  ngOnInit(){

    this.user = JSON.parse(
      localStorage.getItem('user') || '{}'
    );

  }

}
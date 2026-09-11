import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-loginform',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './loginform.html',
  styleUrl: './loginform.css'
})
export class Loginform {

  constructor(private router: Router) {}

  loginForm = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),

    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6)
    ])
  });

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  login() {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    const user = JSON.parse(localStorage.getItem('user') || '{}');

    if (
      user.email === this.loginForm.value.email &&
      user.password === this.loginForm.value.password
    ) {
      localStorage.setItem('isLoggedIn', 'true');
      this.router.navigate(['/profile']);
    } else {
      alert('Invalid Email Or Password');
    }
  }
}
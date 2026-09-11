import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
  ValidationErrors,
  AbstractControl
} from '@angular/forms';

@Component({
  selector: 'app-registerform',
  imports: [ReactiveFormsModule],
  templateUrl: './registerform.html',
  styleUrl: './registerform.css'
})
export class Registerform {

  registerForm = new FormGroup(
    {
      name: new FormControl('', [
        Validators.required
      ]),

      email: new FormControl('', [
        Validators.required,
        Validators.email
      ]),

      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6)
      ]),

      confirmPassword: new FormControl('', [
        Validators.required
      ])
    },
    {
      validators: this.passwordMatchValidator
    }
  );

  passwordMatchValidator(
    control: AbstractControl
  ): ValidationErrors | null {

    const password =
      control.get('password')?.value;

    const confirmPassword =
      control.get('confirmPassword')?.value;

    if (password === confirmPassword) {
      return null;
    }

    return {
      passwordMismatch: true
    };
  }

  register() {

    if (this.registerForm.invalid)
      return;

    localStorage.setItem(
      'user',
      JSON.stringify(this.registerForm.value)
    );

    alert('Account Created Successfully');

    this.registerForm.reset();
  }
}
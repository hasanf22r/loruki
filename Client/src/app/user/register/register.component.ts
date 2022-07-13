import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GeneralService } from 'src/app/services/general.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  constructor(private gService:GeneralService) {}

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      username: new FormControl(),
      password: new FormControl(),
      repassword: new FormControl(),
      email: new FormControl(),
    });
  }
  onClick() {
    this.gService.httpPost('account/login', this.registerForm.value).subscribe(next=>{
      
    })
  }
}

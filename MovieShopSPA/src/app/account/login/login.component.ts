import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/shared/modules/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login : Login = {
    email : "",
    password : ""
  }

  constructor() { }

  ngOnInit(): void {
  }

  submit(){

  }

}

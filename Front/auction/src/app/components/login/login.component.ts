import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service/user.service';
import { Token } from 'src/app/models/token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  message: string;

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit() {
    this.message = '';
  }

  onLogin(email: string, password: string) {
    this.userService.getNewToken(email, password, (tok) => {
      if (tok) {
        this.message = 'Logged';
        this.router.navigate(['/lots']);
        return;
      }

      this.message = 'Error';
    });
  }

}

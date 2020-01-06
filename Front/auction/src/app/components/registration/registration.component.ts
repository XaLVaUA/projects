import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  onRegistration(userName: string, email: string, password: string) {
    this.userService.deleteToken();
    this.userService.registerUser(userName, email, password).subscribe(response => {
      if (response.status === 204) {
        this.router.navigate(['/login']);
      }
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { UserService } from './services/user.service/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'auction';

  constructor(
    private userService: UserService
  ) { }

  onLogout(): void {
    this.userService.deleteToken();
  }
}

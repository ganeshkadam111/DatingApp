import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();

  model: any = {};

  constructor(private authService: AuthService, private alertifyService: AlertifyService) { }

  ngOnInit() {
  }

  register() {

    this.authService.register(this.model).subscribe(() => {
      this.alertifyService.success('registration Successfulll');
    }, error => {
      this.alertifyService.error(error.statusText);
    });

  }
  cancel() {
    this.cancelRegister.emit(false);
  }
}

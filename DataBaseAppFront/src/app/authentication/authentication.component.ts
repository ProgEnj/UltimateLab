import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpService } from '../http.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-authentication',
  standalone: true,
  imports: [ ReactiveFormsModule, FormsModule ],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.scss'
})
export class AuthenticationComponent {
  constructor(private http: HttpService, private router: Router){};

  login: string = "";
  password: string = "";
  priority: number = 1;

  isSuccesfull: boolean = true;

  TryLogin(): void {
    this.http.GetAuthenticate("/authentication", `?username=${this.login}&password=${this.password}`).subscribe(x => this.GrantAccess(x.authenticate));
  }

  GrantAccess(s: boolean): void{
    if(s){
      this.router.navigate(['/main', { priority: this.priority }]);
    }
    else{
      this.isSuccesfull = false;
    }
  }
}

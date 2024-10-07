import { Component } from '@angular/core';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpService } from '../http.service';


@Component({
  selector: 'app-sender',
  standalone: true,
  imports: [MatInputModule, ReactiveFormsModule, MatSelect, MatOption],
  templateUrl: './sender.component.html',
  styleUrl: './sender.component.scss'
})
export class SenderComponent {
  constructor(private http: HttpService) {}
  weatherForm = new FormGroup({
    temp: new FormControl('', Validators.required),
    date: new FormControl('', Validators.required),
    summary: new FormControl('', Validators.required),
  });

  onSubmit(){
  }
}

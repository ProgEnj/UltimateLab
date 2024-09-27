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
  summaryOptions: string[] = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
  weatherForm = new FormGroup({
    temp: new FormControl('', Validators.required),
    date: new FormControl('', Validators.required),
    summary: new FormControl('', Validators.required),
  });

  onSubmit(){
    this.http.PostData('/weatherforecasts', {id: 0, temp: Number(this.weatherForm.value.temp), date: this.weatherForm.value.date!, summary: String(this.weatherForm.value.summary)});
  }

}

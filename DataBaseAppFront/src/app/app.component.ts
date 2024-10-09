import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ControlComponent } from './control/control.component';
import { SenderComponent } from './sender/sender.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ControlComponent, SenderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'DataBaseAppFront';
}

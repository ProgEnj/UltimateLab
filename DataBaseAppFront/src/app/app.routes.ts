import { Routes } from '@angular/router';
import { AuthenticationComponent } from './authentication/authentication.component';
import { MainComponent } from './main/main.component';

export const routes: Routes = [
  { path: 'main', component: MainComponent },
  { path: 'login', component: AuthenticationComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

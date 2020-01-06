import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LotsComponent } from './components/lots/lots.component';
import { LoginComponent } from './components/login/login.component';
import { BetsComponent } from './components/bets/bets.component';
import { LotComponent } from './components/lot/lot.component';
import { HomeComponent } from './components/home/home.component';
import { RegistrationComponent } from './components/registration/registration.component';


const routes: Routes = [
  { path: '', redirectTo: 'lots', pathMatch: 'full'},
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'lots', component: LotsComponent },
  { path: 'lots/:id', component: LotComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FileContentComponent } from '../controls/file-content/file-content.component';
import { HomePageComponent } from '../controls/home-page/home-page.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomePageComponent },
  { path: 'file-content/:id', component: FileContentComponent },
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

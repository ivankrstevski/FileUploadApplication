import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ChartsModule } from 'ng2-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { HomePageComponent } from './controls/home-page/home-page.component';
import { FileUploadComponent } from './controls/file-upload/file-upload.component';
import { UploadedFilesListComponent } from './controls/uploaded-files-list/uploaded-files-list.component';
import { NavBarComponent } from './controls/nav-bar/nav-bar.component';
import { FileContentComponent } from './controls/file-content/file-content.component';
import { NoResultBoxComponent } from './controls/no-result-box/no-result-box.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    FileUploadComponent,
    UploadedFilesListComponent,
    NavBarComponent,
    FileContentComponent,
    NoResultBoxComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ChartsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

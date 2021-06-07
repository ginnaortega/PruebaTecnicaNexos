import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LibroComponent } from './libro/libro.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppConfig } from './app.config';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  { path: 'libro', component: LibroComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    LibroComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    BrowserModule,
    AppRoutingModule
  ],
  exports: [
    CommonModule
  ],
  providers: [AppConfig],
  bootstrap: [AppComponent]
})
export class AppModule { }

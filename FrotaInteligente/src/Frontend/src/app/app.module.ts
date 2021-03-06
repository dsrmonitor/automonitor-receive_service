import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {AppRoutingModule} from "./app.router";
import {HttpClientModule} from "@angular/common/http";
import {MatIconModule} from "@angular/material";
import {MatCheckboxModule} from '@angular/material/checkbox';
import {FormsModule} from "@angular/forms";
import { NgxMaskModule } from 'ngx-mask';
import { ToastrModule } from 'ngx-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {LoginService} from "./login/login.service";
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import {HomeService} from "./home/home.service";
import { VehiclesComponent } from './vehicles/vehicles.component';
import { VehiclesCadastrarComponent} from './vehicles/vehicles-cadastrar.component';
import { BlockUIModule } from 'ng-block-ui';
import {VehiclesService} from "./vehicles/vehicles.service";
import { LocalizationComponent } from './localization/localization.component';
import { AgmCoreModule } from '@agm/core';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    MenuComponent,
    VehiclesComponent,
    VehiclesCadastrarComponent,
    LocalizationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MatIconModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatCheckboxModule,
    ToastrModule.forRoot(),
    BlockUIModule.forRoot(),
    NgxMaskModule.forRoot(),
    AgmCoreModule.forRoot({
      apiKey:'AIzaSyDWbkfyG-0wuE8O0oPgIO4wWwbaUc9CFLk'
    })
  ],
  providers: [LoginService,HomeService, VehiclesService],
  bootstrap: [AppComponent]
})
export class AppModule { }

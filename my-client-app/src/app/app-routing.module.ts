import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { FormComponent } from './form/form.component';
import { SelectFormComponent } from './select-form/select-form.component';

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'formDetails', component: FormComponent },
  { path: 'form', component: SelectFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})

export class AppRoutingModule { }
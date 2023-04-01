import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  registrationForm: FormGroup;
  typeValue: string[] = [];
  formData: CreateFormDto = {
    name: '',
    inputComponents: [{
      label: '',
      name: '',
      type: '',
      inputValues: [{
        'value': ''
      }]
    }]
  };

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.registrationForm = new FormGroup({
      formName: new FormControl(''),
      formTemplate: new FormArray([
        new FormGroup({
          label: new FormControl(''),
          inputName: new FormControl(''),
          type: new FormControl(''),
          values: new FormControl('')
        })
      ])
    })
  }

  addFormTemplate() {
    const control = <FormArray>this.registrationForm.controls['formTemplate'];
    control.push(
      new FormGroup({
        label: new FormControl(''),
        inputName: new FormControl(''),
        type: new FormControl(''),
        values: new FormControl('')
      })
    ); 
  }

  removeFormTemplate(index) {
    const control = <FormArray>this.registrationForm.controls['formTemplate'];
    control.removeAt(index);
  }

  submitForm(){
    const formNameValue = this.registrationForm.get('formName').value;
    const inputComponentsValue = this.registrationForm.get('formTemplate').value.map((input: any) => {
      return {
        label: input.label,
        name: input.inputName,
        type: input.type,
        inputValues: input.values.split(',').map((input: any) => {
          return {
            value: input
          }
        })
      };
    });

    const createFormDto: CreateFormDto = {
      name: formNameValue,
      inputComponents: inputComponentsValue
    };

    console.log(createFormDto);
    const apiUrl = 'https://localhost:7066/DynamicForm/CreateForm';

    this.http.post<CreateFormDto>(apiUrl, createFormDto).subscribe((data) => {
      alert(data['message']);
    });
  }

  getFormValue(i:number)
  {
    const formTemplateValue = this.registrationForm.get('formTemplate').value;
    const formValue = formTemplateValue[i];

    return formValue;
  }
}

export interface CreateFormDto {
  name: string
  inputComponents: InputComponent[]
}

export interface InputComponent {
  label: string
  name: string
  type: string
  inputValues: InputValue[]
}

export interface InputValue {
  value: string
}
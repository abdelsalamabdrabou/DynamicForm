import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  formInputs: GetFormDto[] = [];
  formNames: string[] = [];
  form: FormGroup;
  id: number;
  checkboxAttr: HTMLInputElement;

  constructor(private http: HttpClient, private route: ActivatedRoute, private fb: FormBuilder)
  { 
    this.form = this.fb.group({}); 
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.id = params['formId'];
    })

    const apiUrl = 'https://localhost:7066/DynamicForm/GetFormInputs?formId=' + this.id;

    this.http.get<GetFormDto[]>(apiUrl).subscribe(
      data => {
        this.formInputs = data["data"];
        this.generateDynamicFormGroup(this.formInputs);        
      },
      error => {
        console.error(error);
      }
    );   
  }

  generateDynamicFormGroup(formInputs)
  {
    for (let index = 0; index < formInputs.length; index++) {
      this.formNames[index] = formInputs[index].name;
    }

    this.formNames.forEach(formName => {
      this.form.addControl(formName, this.fb.control(''));
    });
  }

  updateCheckbox(event: Event) {
    let attr = event.target as HTMLInputElement;

    if (attr.checked) {
      attr.value = attr.checked.toString();
    } else {
      attr.value = attr.checked.toString();
    }  

    console.log(attr.value);
  }

  onSubmit() {
    const formValues = this.form.value;
    const jsonObject = JSON.stringify(formValues);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    const apiUrl = 'https://localhost:7066/DynamicForm/SaveFormData';

    this.http.post(apiUrl, jsonObject, httpOptions).subscribe((data) => {
      alert(data['message']);
    });
  }

}

export interface GetFormDto {
  name: string
  type: string
  label: string
  inputValues: InputValue[]
}

export interface InputValue {
  value: string
}

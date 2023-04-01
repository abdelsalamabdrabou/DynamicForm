import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-select-form',
  templateUrl: './select-form.component.html',
  styleUrls: ['./select-form.component.css']
})
export class SelectFormComponent implements OnInit {
  formsList: GetFormsListDto[] = [];
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    const apiUrl = 'https://localhost:7066/DynamicForm/GetFormsList';

    this.http.get<GetFormsListDto[]>(apiUrl).subscribe(
      data => {
        this.formsList = data["data"];
      },
      error => {
        console.error(error);
      }
    );
  }

  goToForm(id: number): void {
    console.log(id);
    this.router.navigate(['/formDetails']);
  }
}

export interface GetFormsListDto {
  id: string
  name: string
}
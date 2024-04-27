import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { SubHeadMetaData, SubHeadService } from './services/sub-head.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, HttpClientModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  subHeadCode: string = '';
  metaData: SubHeadMetaData[] = [];
  data: any = {};


  constructor(private subHeadService: SubHeadService) {

  }

  onChangefun(event: any) {
    console.log('event is: ', this.data);

  }

  onSearch() {
    console.log(this.subHeadCode);

    this.subHeadService.getSubHeadConfigs(this.subHeadCode).subscribe(response => {
      this.data = {};
      this.metaData = response.metaData;
    });
  }
}

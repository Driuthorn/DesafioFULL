import { Component } from '@angular/core';
import { LoaderService } from 'src/app/service/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent {

  loading: boolean;

  constructor(private LoaderService: LoaderService) {
    this.LoaderService.isLoading.subscribe((load) => {
      this.loading = load;
    })
  }

}

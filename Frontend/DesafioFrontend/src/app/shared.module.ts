import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { FilterPipe } from "./pipes/filter.pipe";
import { FilterComponent } from "./components/elements/filter/filter.component";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    NgbModule,
  ],
  declarations: [
    FilterComponent,
    FilterPipe
  ],
  exports: [
    FilterComponent,
    FilterPipe
  ]
})

export class SharedModule { }

import { Component } from '@angular/core';
import Customer from '../models/Customer';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent {

  customer: Customer = {
    name: "João"
  }

}

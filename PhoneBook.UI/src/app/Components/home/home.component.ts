import { Component, ViewChild} from '@angular/core';
import { Contact } from '../../Models/Contact';
import { ContactService } from '../../Services/contact.service';
import { CommonModule } from '@angular/common';
import { ModalComponent } from '../modal/modal.component';


@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [CommonModule, ModalComponent]
})
export class HomeComponent {
  @ViewChild(ModalComponent) modalComponent!: ModalComponent;
  contacts: Contact[] = [];
  selected_contact: any; 

  constructor(private contactService: ContactService) {}
  
  ngOnInit(){
    this.contactService.getContacts().subscribe(
      (result: Contact[]) => {
        this.contacts = result;
      },
      (error) => {
        console.error('Error fetching contacts:', error);
      }
    );

  }

  openModal(data: any) {
    if (data){
      this.selected_contact = data;
      this.modalComponent.open();
    }
  }

}




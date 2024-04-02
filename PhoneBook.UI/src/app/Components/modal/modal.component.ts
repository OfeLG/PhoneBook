import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { ModalDismissReasons, NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Contact } from '../../Models/Contact';


@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [NgbModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  @ViewChild('content') content: any;
  @Input() selection = {};
  closeResult: string = "";

  constructor(private modalService: NgbModal) {}

  ngOnInit() {
  }

  open() {
    console.log(this.selection);
    this.modalService.open(this.content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }


  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with reason: ${reason}`;
    }
  }
}

import { Component, OnInit, Injector, ViewChild, ElementRef, EventEmitter, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { OrderServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'add-otherdesc',
  templateUrl: './add-otherdesc.component.html',
  styleUrls: ['./add-otherdesc.component.css']
})
export class AddOtherdescComponent extends AppComponentBase implements OnInit {

  @ViewChild('addOtherdescModal') addOtherdescModal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  saving = false;
  active = false;

  orderId = 0;
  otherDesc = '';

  constructor(
    injector: Injector,
    private _orderSerivceProxy: OrderServiceProxy
  ) {
    super(injector)
  }

  ngOnInit() {

  }

  onShown(): void {
    this.active = true;
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }
  show(orderId: number): void {
    this.orderId = orderId;
    this.addOtherdescModal.show();
  }
  save(): void {
    this.saving = true;
    this._orderSerivceProxy.addOtherDesc(this.orderId, this.otherDesc)
      .pipe(finalize(() => { this.saving = false }))
      .subscribe((result) => {
        abp.notify.info('保存成功');
        this.close();
        this.modalSave.emit(null);
      });
  }
  close(): void {
    this.active = false;
    this.addOtherdescModal.hide();
  }
}

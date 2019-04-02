import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { OrderServiceProxy, CreateOrderDto, OrderListDto, UserServiceProxy, UserDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';
import * as moment from 'moment';

@Component({
  selector: 'create-order-modal',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent extends AppComponentBase implements OnInit {

  @ViewChild('createOrderModal') modal: ModalDirective;
  @ViewChild('modalContent') modalContent: ElementRef;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  active = false;
  saving = false;
  order: CreateOrderDto = null;
  chinaDateTime = '';

  constructor(
    injector: Injector,
    private _orderServiceProxy: OrderServiceProxy,
    private _userServiceProxy: UserServiceProxy
  ) {
    super(injector);
    // this.order = new CreateOrderDto();
  }

  ngOnInit() {

  }

  show(): void {
    this.active = true;
    this.modal.show();
    this.order = new CreateOrderDto();
  }

  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    const _this = this;
    $(this.modalContent.nativeElement).find('.datetimepicker').datetimepicker({
      format: 'yyyy-mm-dd',
      language: 'zh-CN',
      autoclose: true,
      minView: 2
    }).on('changeDate', function (ev) {
      console.log(ev);
      _this.order.chinaDateTime = moment(ev.date);
      _this.chinaDateTime = ev.currentTarget.value;
      ev.currentTarget.focus();
      ev.currentTarget.blur();
    });
  }

  save(): void {
    // TODO: Refactor this, don't use jQuery style code
    const roles = [];
    $(this.modalContent.nativeElement).find('[name=role]').each((ind: number, elem: Element) => {
      if ($(elem).is(':checked') === true) {
        roles.push(elem.getAttribute('value').valueOf());
      }
    });


    this.saving = true;
    this._orderServiceProxy.createOrder(this.order)
      .pipe(finalize(() => { this.saving = false; }))
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(null);
      });
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }

}

import { TestBed } from '@angular/core/testing';

import { AdCardService } from './ad-card.service';

describe('AdCardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AdCardService = TestBed.get(AdCardService);
    expect(service).toBeTruthy();
  });
});

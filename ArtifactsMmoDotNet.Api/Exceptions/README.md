﻿# Error Codes

# General
code_invalid_payload: int = 422
code_too_many_requests: int = 429
code_not_found: int = 404
code_fatal_error: int = 500

# Account Error Codes
code_token_invalid: int = 452
code_token_expired: int = 453
code_token_missing: int = 454
code_token_generation_fail: int = 455
code_username_already_used: int = 456
code_email_already_used: int = 457
code_same_password: int = 458
code_current_password_invalid: int = 459

# Character Error Codes
code_character_maximum_utilitys_equiped: int = 484
code_character_item_already_equiped: int = 485
code_character_locked: int = 486
code_character_not_this_task: int = 474
code_character_too_many_items_task: int = 475
code_character_no_task: int = 487
code_character_task_not_completed: int = 488
code_character_already_task: int = 489
code_character_already_map: int = 490
code_character_slot_equipment_error = 491
code_character_gold_insufficient: int = 492
code_character_not_skill_level_required: int = 493
code_character_name_already_used: int = 494
code_max_characters_reached: int = 495
code_character_not_level_required: int = 496
code_character_inventory_full: int = 497
code_character_not_found: int = 498
code_character_in_cooldown: int = 499

# Item Error Codes
code_item_insufficient_quantity: int = 471
code_item_invalid_equipment: int = 472
code_item_recycling_invalid_item = 473
code_item_invalid_consumable: int = 476
code_missing_item: int = 478

# Grand Exchange Error Codes
code_ge_max_quantity: int = 479
code_ge_not_in_stock: int = 480
code_ge_not_the_price: int = 482
code_ge_transaction_in_progress: int = 436
code_ge_no_orders: int = 431
code_ge_max_orders: int = 433
code_ge_too_many_items: int = 434
code_ge_same_account: int = 435
code_ge_invalid_item: int =  437
code_ge_not_your_order: int = 438

# Bank
code_bank_insufficient_gold: int = 460
code_bank_transaction_in_progress: int = 461
code_bank_full: int = 462

# Maps Error Codes
code_map_not_found: int = 597
code_map_content_not_found: int = 598

#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>

void start_func(void);
void stop_func(void);

static int __init init(void) {
	start_func();
	return 0;
}

static void __exit clean(void) {
	stop_func();
}

module_init(init);
module_exit(clean);
